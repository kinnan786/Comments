using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Comments.Data.Implementation
{
    public abstract class SmoEntitiesBase : DbContext
    {
        private static readonly string _connectionstring =
            "server=localhost;user id = kinnan; password=root;database=comments";


        public SmoEntitiesBase()
            : base(
                new MySqlConnection(
                    "server=localhost;user id = kinnan; password=root;database=comments"), false
                )
        {
        }

        public override int SaveChanges()
        {
            //Default isolation level is already Snapshot in EF6
            var retVal = 0;
            var tryCount = 0;
            TryLabel:
            try
            {
                retVal = base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                        Trace.TraceError("Validation on Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage);
                }


                throw ex;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                if (ex.Message.StartsWith("Snapshot isolation") && tryCount < 2)
                {
                    tryCount++;
                    Thread.Sleep(10 * tryCount);
                    goto TryLabel;
                }
                Trace.TraceError("SaveChanges Error: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return retVal;
        }
    }
}