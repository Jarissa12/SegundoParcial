using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using  _2doParcial_Nicol.Data;
using  _2doParcial_Nicol.Entidades;
using  _2doParcial_Nicol.BLL;
using System.Linq.Expressions;

namespace _2doParcial_Nicol.BLL
{
    public class VerduraBLL
    {
        private ApplicationDbContext _contexto;

        public VerduraBLL(ApplicationDbContext contexto)
        {
          _contexto=contexto;   
        }

        public bool Existe(int VerduraId)
        {
            return _contexto.Verdura.Any(c => c.VerduraId == VerduraId);
        }
        public bool Guardar(Verduras verdura)
        {
            bool paso = false;

            if (!Existe(verdura.VerduraId))
                paso = Insertar(verdura);
            else
                paso = Modificar(verdura);
                return paso;

        }
        private bool Insertar(Verduras verdura)
        {
            _contexto.Verdura.Add(verdura);
            
            foreach (var item in verdura.Detalle)
            {
                var vitamina = _contexto.Vitamina.Find(item.VitaminaId);
                vitamina!.Existe += item.Cantidad;
            }

            
            bool insertar = _contexto.SaveChanges() >0;
            _contexto.Entry(verdura).State = EntityState.Detached;
            return insertar;           
        }
            
        private bool Modificar(Verduras verdura)
        {
            var anterior = _contexto.Verdura
            .Where(c => c.VerduraId == verdura.VerduraId)
            .Include(c => c.Detalle)
            .AsNoTracking()
            .SingleOrDefault();

            foreach (var item in anterior!.Detalle)
            {
                var vitamina = _contexto.Vitamina.Find(item.VitaminaId);

                vitamina!.Existe -= item.Cantidad;
            }        
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM VerdurasDetalle WHERE VerduraId={verdura.VerduraId};");

            foreach (var item in verdura.Detalle)
            {
                var vitamina = _contexto.Vitamina.Find(item.VitaminaId);
                vitamina!.Existe += item.Cantidad;
                

                _contexto.Entry(item).State = EntityState.Added;
            }

            _contexto.Entry(verdura).State = EntityState.Modified;

            var guardo = _contexto.SaveChanges() > 0;
            _contexto.Entry(verdura).State = EntityState.Detached;
            return guardo;
        }
        public bool Eliminar(Verduras verdura)
        {
            _contexto.Verdura.Add(verdura);
            
            foreach (var item in verdura.Detalle)
            {
                var vitamina = _contexto.Vitamina.Find(item.VitaminaId);
                vitamina!.Existe-= item.Cantidad;
                
            }
            _contexto.Entry(verdura).State = EntityState.Deleted;

            bool elimino = _contexto.SaveChanges() > 0;
            _contexto.Entry(verdura).State = EntityState.Detached;
                
            return elimino;
        } 
        public Verduras? Buscar(int verdura)
        {
            return _contexto.Verdura
            .Include(c => c.Detalle)
            .Where(c => c.VerduraId == verdura)
            .AsNoTracking()
            .SingleOrDefault();
        }
        

        public  List<Verduras> GetVerduras(Expression<Func<Verduras, bool>> Criterio)
        {
            return _contexto.Verdura
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

        

    }
}