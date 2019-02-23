using System.Data;

namespace Recipe.Writers
{
    public interface IWriter
    {
        void Write(DataTable reportData);
    }
}
