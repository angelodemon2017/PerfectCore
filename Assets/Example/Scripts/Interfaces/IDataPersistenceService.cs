public interface IDataPersistenceService
{
    bool SaveModel<T>(T model, string filePath) where T : class, IDataModel;

    T LoadModel<T>(string filePath) where T : class, IDataModel;

    string GetModelPath<T>() where T : class, IDataModel;
}