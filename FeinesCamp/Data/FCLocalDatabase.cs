using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeinesCamp.Model;
using SQLite;

namespace FeinesCamp.Data
{
    public class FCLocalDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public FCLocalDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }


        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return Database.UpdateAsync(user);
            }
            else
            {
                return Database.InsertAsync(user);
            }
        }

        public Task<User> GetUser()
        {
            return  Database.Table<User>().FirstOrDefaultAsync();
        }

        public Task<List<ClientGetDTO>> GetClients()
        {
            return Database.Table<ClientGetDTO>().ToListAsync();
        }

    }
}
