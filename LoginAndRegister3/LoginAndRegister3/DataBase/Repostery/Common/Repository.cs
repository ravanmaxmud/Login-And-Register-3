using Login_and_Register.DataBase.Models;
using Login_and_Register.DataBase.Repostery;
using LoginAndRegister3.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAndRegister3.DataBase.Repostery.Common
{
    public class Repository<TEntity,Tid>
        where TEntity : Entitiy<Tid>
    {
        protected static List<TEntity> DbContent { get; set; } = new List<TEntity>();

        public  TEntity Add(TEntity entity)
        {
            DbContent.Add(entity);
            return entity;
        }
        public static void Delete(TEntity entity) 
        {
            DbContent.Remove(entity);
        }

        public  List<TEntity> GetAll()
        {
            return DbContent;
        }
        public TEntity GetById(Tid id)
        {
            foreach (TEntity entry in DbContent)
            {

                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }
            return default(TEntity);
        }
    }
}
