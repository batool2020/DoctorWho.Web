using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<tblAuthor>> GetAuthorAsync();


        Task<bool> SaveChangesAsync();
        Task<tblAuthor> GetAuthorByIdAsync(int authorid);
    }
}
