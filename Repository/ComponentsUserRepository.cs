using api.Models;

namespace api.Repository
{
    public interface ComponentsUserRepository
    {
        Task<List<UsersModel>> findUsers();

        Task<UsersModel> findById(int id);
        Task<UsersModel> create(UsersModel user);
        Task<UsersModel> update(UsersModel user, int id);
        Task<bool> delete(int id);

    }
}