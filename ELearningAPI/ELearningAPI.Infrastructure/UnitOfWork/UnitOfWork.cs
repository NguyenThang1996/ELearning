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
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface IUnitOfWork
    {
        DataContext _dataContext { get; }
        /// <summary>Begins the transaction.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        void BeginTransaction();

        /// <summary>Commits the transaction.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        void CommitTransaction();

        /// <summary>Rollbacks the transaction.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        void RollbackTransaction();

        /// <summary>Users the repository.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        IUserRepository UserRepository();

        /// <summary>Staffs the repository.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        IStaffRepository StaffRepository();

        /// <summary>Parts the repository.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Initializes a new instance of the <see cref="UnitOfWork" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            _userRepository = new UserRepository(_dataContext);
            _staffRepository = new StaffRepository(_dataContext);
            _partRepository = new PartRepository(_dataContext);
        }

        /// <summary>Begins the transaction.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Commits the transaction.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Rollbacks the transaction.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Users the repository.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Staffs the repository.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Parts the repository.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
