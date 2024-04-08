namespace demo_aspnet.Interfaces;

public interface IUpload
{
    public string Upload(FormFile file);
}