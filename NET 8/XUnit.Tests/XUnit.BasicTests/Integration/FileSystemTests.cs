using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace XUnit.BasicTests.Integration;

[Trait("Category", "Integration")]
[Trait("Component", "FileSystem")]
public class FileSystemTests
{
    private readonly string _testDirectory = Path.Combine(Path.GetTempPath(), "XUnitTests");

    [Fact]
    public async Task FileSystem_CreateFile_CreatesSuccessfully()
    {
        await Task.Delay(200);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "test.txt");
        
        await File.WriteAllTextAsync(filePath, "Test content");
        
        Assert.True(File.Exists(filePath));
        File.Delete(filePath);
    }

    [Fact]
    public async Task FileSystem_ReadFile_ReadsCorrectly()
    {
        await Task.Delay(250);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "test2.txt");
        
        await File.WriteAllTextAsync(filePath, "Test content");
        var content = await File.ReadAllTextAsync(filePath);
        
        Assert.Equal("Test content", content);
        File.Delete(filePath);
    }

    [Fact]
    public async Task FileSystem_DeleteFile_RemovesFile()
    {
        await Task.Delay(200);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "test3.txt");
        
        await File.WriteAllTextAsync(filePath, "Test content");
        File.Delete(filePath);
        
        Assert.False(File.Exists(filePath));
    }

    [Fact]
    public async Task FileSystem_CreateDirectory_CreatesSuccessfully()
    {
        await Task.Delay(150);
        var dirPath = Path.Combine(_testDirectory, "subdir");
        
        Directory.CreateDirectory(dirPath);
        
        Assert.True(Directory.Exists(dirPath));
        Directory.Delete(dirPath);
    }

    [Fact]
    public async Task FileSystem_ListFiles_ReturnsAllFiles()
    {
        await Task.Delay(300);
        Directory.CreateDirectory(_testDirectory);
        var file1 = Path.Combine(_testDirectory, "file1.txt");
        var file2 = Path.Combine(_testDirectory, "file2.txt");
        
        await File.WriteAllTextAsync(file1, "Content 1");
        await File.WriteAllTextAsync(file2, "Content 2");
        
        var files = Directory.GetFiles(_testDirectory);
        Assert.True(files.Length >= 2);
        
        File.Delete(file1);
        File.Delete(file2);
    }

    [Fact]
    public async Task FileSystem_AppendToFile_AppendsCorrectly()
    {
        await Task.Delay(250);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "append.txt");
        
        await File.WriteAllTextAsync(filePath, "Line 1\n");
        await File.AppendAllTextAsync(filePath, "Line 2\n");
        
        var content = await File.ReadAllTextAsync(filePath);
        Assert.Contains("Line 1", content);
        Assert.Contains("Line 2", content);
        
        File.Delete(filePath);
    }

    [Fact]
    public async Task FileSystem_CopyFile_CreatesCorrectCopy()
    {
        await Task.Delay(300);
        Directory.CreateDirectory(_testDirectory);
        var sourcePath = Path.Combine(_testDirectory, "source.txt");
        var destPath = Path.Combine(_testDirectory, "dest.txt");
        
        await File.WriteAllTextAsync(sourcePath, "Original content");
        File.Copy(sourcePath, destPath);
        
        Assert.True(File.Exists(destPath));
        var content = await File.ReadAllTextAsync(destPath);
        Assert.Equal("Original content", content);
        
        File.Delete(sourcePath);
        File.Delete(destPath);
    }

    [Fact]
    public async Task FileSystem_MoveFile_MovesCorrectly()
    {
        await Task.Delay(250);
        Directory.CreateDirectory(_testDirectory);
        var sourcePath = Path.Combine(_testDirectory, "move_source.txt");
        var destPath = Path.Combine(_testDirectory, "move_dest.txt");
        
        await File.WriteAllTextAsync(sourcePath, "Move content");
        File.Move(sourcePath, destPath);
        
        Assert.False(File.Exists(sourcePath));
        Assert.True(File.Exists(destPath));
        
        File.Delete(destPath);
    }

    [Fact]
    public async Task FileSystem_GetFileInfo_ReturnsCorrectInfo()
    {
        await Task.Delay(200);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "info.txt");
        
        await File.WriteAllTextAsync(filePath, "Test");
        var fileInfo = new FileInfo(filePath);
        
        Assert.True(fileInfo.Exists);
        Assert.True(fileInfo.Length > 0);
        
        File.Delete(filePath);
    }

    [Fact]
    public async Task FileSystem_FileNotFound_ThrowsException()
    {
        await Task.Delay(150);
        var filePath = Path.Combine(_testDirectory, "nonexistent.txt");
        
        await Assert.ThrowsAsync<FileNotFoundException>(async () =>
        {
            await File.ReadAllTextAsync(filePath);
        });
    }

    [Fact]
    public async Task FileSystem_WriteLargeFile_Succeeds()
    {
        await Task.Delay(500);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "large.txt");
        
        var largeContent = new string('A', 10000);
        await File.WriteAllTextAsync(filePath, largeContent);
        
        var content = await File.ReadAllTextAsync(filePath);
        Assert.Equal(10000, content.Length);
        
        File.Delete(filePath);
    }

    [Fact]
    public async Task FileSystem_CreateNestedDirectories_Succeeds()
    {
        await Task.Delay(200);
        var nestedPath = Path.Combine(_testDirectory, "level1", "level2", "level3");
        
        Directory.CreateDirectory(nestedPath);
        
        Assert.True(Directory.Exists(nestedPath));
        
        Directory.Delete(Path.Combine(_testDirectory, "level1"), true);
    }

    [Fact]
    public async Task FileSystem_FileAttributes_WorkCorrectly()
    {
        await Task.Delay(250);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "attributes.txt");
        
        await File.WriteAllTextAsync(filePath, "Test");
        File.SetAttributes(filePath, FileAttributes.ReadOnly);
        
        var attributes = File.GetAttributes(filePath);
        Assert.True(attributes.HasFlag(FileAttributes.ReadOnly));
        
        File.SetAttributes(filePath, FileAttributes.Normal);
        File.Delete(filePath);
    }

    [Fact]
    public async Task FileSystem_StreamOperations_WorkCorrectly()
    {
        await Task.Delay(300);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "stream.txt");
        
        using (var stream = File.Create(filePath))
        using (var writer = new StreamWriter(stream))
        {
            await writer.WriteLineAsync("Line from stream");
        }
        
        using (var stream = File.OpenRead(filePath))
        using (var reader = new StreamReader(stream))
        {
            var content = await reader.ReadToEndAsync();
            Assert.Contains("Line from stream", content);
        }
        
        File.Delete(filePath);
    }

    [Fact]
    public async Task FileSystem_BinaryFile_HandlesCorrectly()
    {
        await Task.Delay(400);
        Directory.CreateDirectory(_testDirectory);
        var filePath = Path.Combine(_testDirectory, "binary.dat");
        
        var data = new byte[] { 0, 1, 2, 3, 4, 5 };
        await File.WriteAllBytesAsync(filePath, data);
        
        var readData = await File.ReadAllBytesAsync(filePath);
        Assert.Equal(data, readData);
        
        File.Delete(filePath);
    }
}
