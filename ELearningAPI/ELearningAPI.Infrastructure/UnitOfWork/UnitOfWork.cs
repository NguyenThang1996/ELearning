using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ELearningAPI.Infrastructure.Configs;
using ELearningAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ELearningAPI.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        DataContext _dataContext { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IUserRepository UserRepository();
        IStaffRepository StaffRepository();
        IPartRepository PartRepository();
    }
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext _dataContext { get; private set; }
        private IDbContextTransaction _transaction;
        private IsolationLevel? _isolationLevel;
        private UserRepository _userRepository { get; }
        private StaffRepository _staffRepository { get; }
        private PartRepository _partRepository { get; }
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            _userRepository = new UserRepository(_dataContext);
            _staffRepository = new StaffRepository(_dataContext);
            _partRepository = new PartRepository(_dataContext);
        }
        public void BeginTransaction()
        {
            try
            {
                if (_transaction == null)
                {
                    _transaction = _isolationLevel.HasValue ?
                         _dataContext.Database.BeginTransaction(_isolationLevel.GetValueOrDefault()) : _dataContext.Database.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CommitTransaction()
        {
            try
            {
                _dataContext.SaveChanges();
                if (_transaction == null) return;
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
            catch (Exception ex)
            { 
                throw;
            }

        }
        public void RollbackTransaction()
        {
            try
            {
                if (_transaction == null) return;
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public IUserRepository UserRepository()
        {
            try
            {
                return _userRepository;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IStaffRepository StaffRepository()
        {
            try
            {
                return _staffRepository;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IPartRepository PartRepository()
        {
            try
            {
                return _partRepository;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
