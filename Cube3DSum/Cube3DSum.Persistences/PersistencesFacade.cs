using System.Data.Entity;
using System.Linq;
using Cube3D.Entity;
using System.Collections.Generic;

namespace Cube3D.Persistences
{
    public class PersistencesFacade
    {
        private static PersistencesFacade _instance=null;

        internal PersistencesFacade(){}

        public static PersistencesFacade GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersistencesFacade();
                return _instance;
            }
        }

        public bool SaveInfMatrix(Matriz entity)
        {
            using (var db = new Cube3DContext())
            {
                if (entity.Id == 0)
                    db.Matriz.Add(entity);
                else
                {
                    if (db.Entry(entity).State == EntityState.Detached)
                        db.Matriz.Attach(entity);

                    db.Entry(entity).State = EntityState.Modified;
                }
                
                var result=db.SaveChanges();
                return (result > 0);
            }
        }

        public List<DetalleMatriz> GetDetalleMatrix(int MatrixId)
        {
            using (var db = new Cube3DContext())
            {
                return db.DetalleMatriz.Where(p => p.MatrizId ==MatrixId).ToList();
            }
        }

        public bool SaveDetMatrix(DetalleMatriz entity)
        {
            using (var db = new Cube3DContext())
            {
                if (entity.Id == 0)
                    db.DetalleMatriz.Add(entity);
                else
                {
                    if (db.Entry(entity).State == EntityState.Detached)
                        db.DetalleMatriz.Attach(entity);

                    db.Entry(entity).State = EntityState.Modified;
                }
                var result=db.SaveChanges();
                return (result > 0);
            }
        }
    }
}
