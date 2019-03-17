using System.Data;

namespace Cooking.Writers
{
    public interface IWriter
    {
        void Write(DataTable reportData);
    }
}
