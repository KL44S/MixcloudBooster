using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongodbAccess.Implementations;
using MongodbAccess.Model;
using MongodbAccess.Services;
using RepositoryAccess;

namespace DataAccessServices.Factories
{
    internal class RepositoryFactory
    {
        public enum Tech { Mongodb };

        public static IGetRepository<T> BuildAndGetGetRepository<T>(Tech tech, IConfiguration configuration)
        {
            IGetRepository<T> getRepository = null;

            switch (tech)
            {
                case Tech.Mongodb:
                    getRepository = new MongodbGetRepository<T>(GetMongoDatabase(configuration));
                    break;
            }

            return getRepository;
        }

        public static ISaveRepository<T> BuildAndGetSaveRepository<T>(Tech tech, IConfiguration configuration)
        {
            ISaveRepository<T> saveRepository = null;

            switch (tech)
            {
                case Tech.Mongodb:
                    saveRepository = new MongodbSaveRepository<T>(GetMongoDatabase(configuration));
                    break;
            }

            return saveRepository;
        }

        public static IDeleteRepository<T> BuildAndGetDeleteRepository<T>(Tech tech, IConfiguration configuration)
        {
            IDeleteRepository<T> deleteRepository = null;

            switch (tech)
            {
                case Tech.Mongodb:
                    deleteRepository = new MongodbDeleteRepository<T>(GetMongoDatabase(configuration));
                    break;
            }

            return deleteRepository;
        }

        private static IMongoDatabase GetMongoDatabase(IConfiguration configuration)
        {
            string mongodbConfigKey = "Mongodb";

            MongodbConfig mongodbConfig = configuration.GetSection(mongodbConfigKey).Get<MongodbConfig>();
            IMongoDatabase database = MongodbProvider.GetDatabase(mongodbConfig);

            return database;
        }
    }
}
