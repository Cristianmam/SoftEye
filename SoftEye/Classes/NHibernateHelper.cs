using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace SoftEye.Classes
{
    public sealed class NHibernateHelper
    {
        private static readonly ISessionFactory _sessionFactory;

        private ISession currentSession = null;

        static NHibernateHelper()
        {
            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }
        public ISession GetCurrentSession()
        {
            if (currentSession == null)
            {
                currentSession = _sessionFactory.OpenSession();
            }
            return currentSession;
        }
        public void CloseSession()
        {
            if (currentSession == null)
            {
                // No current session
                return;
            }
            currentSession.Close();
            currentSession = null;
        }
        public void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}

