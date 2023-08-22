
public class FileService
{
    private string filePathRead;
    private string filePathWrite;

    public FileService(string filePathRead, string filePathWrite)
    {
        this.filePathRead = filePathRead;
        this.filePathWrite = filePathWrite;
    }

    public string ReadFromFile()
    {
        if (File.Exists(filePathRead))
        {
            return File.ReadAllText(filePathRead);
        }
        return "File Not Exists";
    }
    public string WriteToFile(string content)
    {
        if( content != string.Empty)
        {
        File.WriteAllText(filePathWrite, content);
        }
        return "Data not Available";      
    }
}