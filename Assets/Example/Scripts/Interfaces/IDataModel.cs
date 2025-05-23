public interface IDataModel
{
    void UpdateModelByLiteMessage(string message);
    string GetLiteMessage(int deepH, out int maxDepth);
}