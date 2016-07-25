using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cube3D.Entity;
using Cube3D.Persistences;

namespace Cube3D.BusinessRules
{
    public class Cube3DSum
    {
        public enum key
        {
            UPDATE,
            QUERY
        }
        public int[,,] SizingCube(int tamM)
        {
            var m = new int[tamM, tamM, tamM];
            for (int i = 1; i <= tamM; i++)
            {
                for (int j = 1; j <= tamM; j++)
                {
                    for (int k = 1; k <= tamM; k++)
                    {
                        m[i, j, k] = 0;
                    }
                }
            }
            return m;
        }
        
        public int CubeSum3(string query, int[,,] matrix)
        {
            var nque = query.Replace(key.QUERY.ToString(), "");
            var coordxIn = Convert.ToInt32(query.Split(';')[0]);
            var coordyIn = Convert.ToInt32(query.Split(';')[1]);
            var coordzin = Convert.ToInt32(query.Split(';')[2]);
            var coordxFn = Convert.ToInt32(query.Split(';')[3]);
            var coordyFn = Convert.ToInt32(query.Split(';')[4]);
            var coordzFn = Convert.ToInt32(query.Split(';')[5]);

            var result = 0;
            for (int i = coordxIn; i < coordxFn; i++)
            {
                for (int j = coordyIn; i < coordyFn; i++)
                {
                    for (int k = coordzin; i < coordzFn; i++)
                    {
                        if (matrix[i, j, k] > 0)
                            result += matrix[i, j, k];
                    }
                }
            }
            return result;
        }

        public bool SetValues(string query,int matrixId)
        {
            var nQuery = query.Replace(key.UPDATE.ToString(),"");
            var coordx = Convert.ToInt32(query.Split(';')[0]);
            var coordy = Convert.ToInt32(query.Split(';')[1]);
            var coordz = Convert.ToInt32(query.Split(';')[2]);
            var value = Convert.ToInt32(query.Split(';')[4]);

            var m = new DetalleMatriz() { Coordenada = coordx + "," + coordy + "," + coordz, Valor = value, MatrizId=matrixId };
            return PersistencesFacade.GetInstance.SaveDetMatrix(m);
            
        }

        public bool InsertMatriz(Matriz entity)
        {
            return PersistencesFacade.GetInstance.SaveInfMatrix(entity);
        }

        public int[, ,] SetValuesMatrix(int IdMatrix,int[,,] Matrix)
        {
            List<DetalleMatriz> list=PersistencesFacade.GetInstance.GetDetalleMatrix(IdMatrix);
            if(list.Count > 0)
                foreach (var item in list)
                {
                    int x,y,z=0;
                    int.TryParse(item.Coordenada.Split(',')[0],out x);

                    int.TryParse(item.Coordenada.Split(',')[1],out y);
                    int.TryParse(item.Coordenada.Split(',')[2], out z);
                    Matrix[x, y, z] = item.Valor;
                }
            return Matrix;
        }

    }
}
