using EasyCook3.Core.Helpers;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EasyCook3.Data
{
    public class MySQLiService
    {
        private static SQLiteAsyncConnection _database;

        public MySQLiService()
        {
            // Ruta de la base de datos
            //var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "app.db3");
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "app.db3");

            // Crear la conexión a la base de datos
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<UserLoginDTO>();
            _database.CreateTableAsync<Recipe>();
            _database.CreateTableAsync<Ingredient>();
            _database.CreateTableAsync<Step>();
            _database.CreateTableAsync<Comment>();
        }

        // Inicializar la base de datos (crear tablas si no existen)
        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<UserLoginDTO>();
            await _database.CreateTableAsync<Recipe>();
            await _database.CreateTableAsync<Ingredient>();
            await _database.CreateTableAsync<Step>();
            await _database.CreateTableAsync<Comment>();
        }

        #region USER
        public  async Task<int> AddUserAsync(UserLoginDTO user)
        {
            await _database.DeleteAllAsync<UserLoginDTO>();
            return await _database.InsertAsync(user);
        }
        public async Task<List<UserLoginDTO>> GetAllUser()
        {
            return await _database.Table<UserLoginDTO>().ToListAsync();
        }
        public async Task<UserLoginDTO> FindUser(UserLoginDTO userdto)
        {
            var instance = new MySQLiService();
            var passEncrypt = await EncryptPassSha25(userdto.Password);
            var user = await _database.Table<UserLoginDTO>().Where(u => u.Username == userdto.Username && u.Password == passEncrypt).FirstOrDefaultAsync();
            return user;
        }
        public async Task DropTableUserAsync()
        {
            await _database.DeleteAllAsync<UserLoginDTO>();
        }

        #endregion

        #region RECIPE
        public async Task<int> AddRecipeAsync(Recipe recipe)
        {
            return await _database.InsertAsync(recipe);
        }
        public async Task<bool> FinRecipeById(int id)
        {
            var data = await _database.Table<Recipe>().Where(r => r.Id == id).FirstOrDefaultAsync();

            if (data != null)
            {
                return true;
            }

            return false;
        }
        public async Task<Recipe> ReturnRecipe(int id)
        {
            return await _database.Table<Recipe>().Where(r => r.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Recipe>> GetRecipesAsync()
        {
            var data = await _database.Table<Recipe>().ToListAsync();
            return data;
        }
        public async void DeleteRecipe(int id)
        {
            _database.Table<Recipe>().DeleteAsync(r => r.Id == id);
        }
        public async Task DropTableRecipeAsync()
        {
            await _database.DeleteAllAsync<Recipe>();
        }

        #endregion

        #region INGREDIENT
        public async Task<int> AddIngredientAsync(Ingredient ing)
        {
            return await _database.InsertAsync(ing);
        }
        public async Task<List<Ingredient>> GetIngredientAsync(int recipeId)
        {
            var data = await _database.Table<Ingredient>().Where(i => i.RecipeId == recipeId).ToListAsync();
            return data;
        }
        public async void DeleteIngredient(int recipeId)
        {
            _database.Table<Ingredient>().DeleteAsync(i => i.RecipeId == recipeId);
        }
        public async Task DropTableIngredientAsync()
        {
            await _database.DeleteAllAsync<Ingredient>();
        }

        #endregion

        #region STEP
        public async Task<int> AddStepAsync(Step step)
        {
            return await _database.InsertAsync(step);
        }
        public async Task<List<Step>> GetStepsAsync(int recipeId)
        {
            return await _database.Table<Step>().Where(s => s.RecipeId == recipeId).ToListAsync();
        }
        public async void DeleteSteps(int recipeId)
        {
            await _database.Table<Step>().DeleteAsync(s => s.RecipeId == recipeId);
        }
        public async Task DropTableStepAsync()
        {
            await _database.DeleteAllAsync<Step>();
        }

        #endregion

        #region COMMENT
        public async Task<int> AddCommentAsync(Comment com)
        {
            return await _database.InsertAsync(com);
        }
        public async Task<List<Comment>> GetCommentAsync(int recipeId)
        {
            return await _database.Table<Comment>().Where(c => c.RecipeId == recipeId).ToListAsync();
        }
        public async void DeleteComment(int recipeId)
        {
            await _database.Table<Comment>().DeleteAsync(c => c.RecipeId == recipeId);
        }
        public async Task DropTableCommentAsync()
        {
            await _database.DeleteAllAsync<Comment>();
        }

        #endregion

        public async Task<List<Ingredient>> getallingredient()
        {
            return await _database.Table<Ingredient>().ToListAsync();
        }
        public async Task<List<Step>> getallstep()
        {
            return await _database.Table<Step>().ToListAsync();
    }
        public async Task<List<Comment>> getallcomment()
        {
        return await _database.Table<Comment>().ToListAsync();
    }

        public async Task<string> EncryptPassSha25(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

            return sb.ToString();
        }
    }
}
