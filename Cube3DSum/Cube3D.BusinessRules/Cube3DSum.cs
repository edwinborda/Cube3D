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
            
            return m;
        }
        
        public int CubeSum3(string query, int[,,] matrix)
        {
            var nque = query.Replace(key.QUERY.ToString()+" ", "");
            var coordxIn = Convert.ToInt32(nque.Split(' ')[0]);
            var coordyIn = Convert.ToInt32(nque.Split(' ')[1]);
            var coordzin = Convert.ToInt32(nque.Split(' ')[2]);
            var coordxFn = Convert.ToInt32(nque.Split(' ')[3]);
            var coordyFn = Convert.ToInt32(nque.Split(' ')[4]);
            var coordzFn = Convert.ToInt32(nque.Split(' ')[5]);

            var result = 0;
            for (int i = coordxIn-1; i < matrix.GetLength(0); i++)
            {
                for (int j = coordyIn-1; j < matrix.GetLength(1); j++)
                {
                    for (int k = coordzin-1; k < matrix.GetLength(2); k++)
                    {

                        if (matrix[i, j, k] > 0)
                            result += matrix[i, j, k];

                        if (i == coordxFn-1 && j == coordyFn-1 && k == coordzFn-1)
                            return result;
                    }
                }
            }
            return result;
        }

        public bool SetValues(string query,int matrixId)
        {
            var nQuery = query.Replace(key.UPDATE.ToString()+" ","");
            var coordx = Convert.ToInt32(nQuery.Split(' ')[0]);
            var coordy = Convert.ToInt32(nQuery.Split(' ')[1]);
            var coordz = Convert.ToInt32(nQuery.Split(' ')[2]);
            var value = Convert.ToInt32(nQuery.Split(' ')[3]);

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
                    Matrix[x-1, y-1, z-1] = item.Valor;
                }
            return Matrix;
        }

        public Matriz GetMatriz(int length)
        {
            return PersistencesFacade.GetInstance.GetMatrixBySize(length);
        }
    }
}
