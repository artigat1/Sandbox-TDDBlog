using System;

namespace TDDBlog.Data
{
    public interface ICoreUnitOfWork : IDisposable
    {
        /// <summary>
        ///   <para>Commit</para>
        /// </summary>
        void Commit();
    }
}
