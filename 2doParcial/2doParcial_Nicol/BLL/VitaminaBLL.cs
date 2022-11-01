using Microsoft.EntityFrameworkCore;
using _2doParcial_Nicol.Entidades;
using System.Linq.Expressions;
using  _2doParcial_Nicol.Data;

namespace _2doParcial_Nicol.BLL
{
    public class VitaminaBLL
    {

        private ApplicationDbContext _contexto;

        public VitaminaBLL(ApplicationDbContext contexto)
        {
          _contexto=contexto;   
        }


        public bool Existe(int VitaminaId){

            return _contexto.Vitamina.Any(p => p.VitaminaId == VitaminaId);


        }   

        public  bool Guardar(Vitaminas vitamina)
        {
            if (!Existe(vitamina.VitaminaId))
                return this.Insertar(vitamina);
            else
                return  this.Modificar(vitamina);
        } 

        public  bool Eliminar(Vitaminas vitamina)
        {
            if (!Existe(vitamina.VitaminaId))
                return this.Insertar(vitamina);
            else
                return  this.Modificar(vitamina);
        } 

         public  bool Insertar (Vitaminas vitamina)
        {
            _contexto.Vitamina.Add(vitamina);
             return _contexto.SaveChanges()> 0;

        } 

         public  Vitaminas? Buscar(int VitaminaId){
            return _contexto.Vitamina
                    .Where(o=> o.VitaminaId== VitaminaId)
                    .AsNoTracking()
                    .SingleOrDefault();
                    
        }

        
        public  bool Modificar (Vitaminas vitamina)
        {
            
          _contexto.Entry(vitamina).State = EntityState.Modified;
            return   _contexto.SaveChanges()> 0;

        } 

       
       public  List<Vitaminas> GetVitaminas(Expression<Func<Vitaminas, bool>> Criterio)
        {
            return _contexto.Vitamina
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

        

    }   

}       
       