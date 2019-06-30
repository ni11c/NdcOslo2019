using System.Threading.Tasks;

namespace Nde.NdcOlso2019.Storage
{
    public interface ICloudStorage
    {
        #region Services

        Task<bool> InsertToTable<T>(T entity, string tableName);

        #endregion
    }
}