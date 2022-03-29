﻿using Microsoft.EntityFrameworkCore;
using Projeto.Dominio.Interfaces;
using Projeto.Infra.Dados.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Dados.Repositorio
{
    public class RepositorioBase<T> : IBase<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<EstacaoRecargaDbContext> _optionsBuilder;

        public RepositorioBase()
        {
            _optionsBuilder = new DbContextOptions<EstacaoRecargaDbContext>();
        }

        public void Adicionar(T obj)
        {
            using (var db = new EstacaoRecargaDbContext(_optionsBuilder))
            {
                try
                {
                    db.Set<T>().Add(obj);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public T RecuperarPorId(Guid id)
        {
            using (var db = new EstacaoRecargaDbContext(_optionsBuilder))
            {
                return db.Set<T>().Find(id);
            }
        }

        public void Atualizar(T obj)
        {
            using (var db = new EstacaoRecargaDbContext(_optionsBuilder))
            {
                db.Set<T>().Update(obj);
                db.SaveChanges();
            }
        }

        public void Excluir(T obj)
        {
            using (var db = new EstacaoRecargaDbContext(_optionsBuilder))
            {
                db.Set<T>().Remove(obj);
                db.SaveChanges();
            }
        }

        public IReadOnlyList<T> Listar()
        {
            using (var db = new EstacaoRecargaDbContext(_optionsBuilder))
            {
                return db.Set<T>().AsNoTracking().ToList();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
