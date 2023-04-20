using api.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using api.Repository;

namespace api.Repository
{
    public class UserRepository : ComponentsUserRepository
    {
        private readonly FinancesDbContext _dbContext;
        public UserRepository(FinancesDbContext financesDbContext)
        {
            _dbContext = financesDbContext;
        }
        
        public async Task<UsersModel> findById(int id)
        {
            return await _dbContext.users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsersModel>> findUsers()
        {
            return await _dbContext.users.ToListAsync();
        }
        public async Task<UsersModel> create(UsersModel user)
        {
           await _dbContext.users.AddAsync(user);
           await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UsersModel> update(UsersModel user, int id)
        {
           UsersModel findUsersById = await findById(id);

           if(findUsersById == null) 
           {
            throw new Exception("Wasn't possible to update because User nout found in database");
           }
           
            findUsersById.fullName = user.fullName;
            findUsersById.email = user.email;
           
           _dbContext.users.Update(findUsersById);
          await _dbContext.SaveChangesAsync();
           
           return findUsersById;
        }
        public async Task<bool> delete(int id)
        {
           UsersModel findUserById = await findById(id);

           if(findUserById == null) 
           {
                throw new Exception("Wasn't possible to delete because User not found in database");
           }

           _dbContext.users.Remove(findUserById);
           await _dbContext.SaveChangesAsync();
           return true;
        }

    }
}