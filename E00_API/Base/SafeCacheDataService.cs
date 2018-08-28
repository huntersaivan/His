using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Reflection;
using E00_API.Base.Interface;
using E00_Common;
using System.Data.OracleClient;
using System.Data;

namespace E00_API.Base
{
    public class SafeCacheDataService<TInfo> : ICacheDataService<TInfo>
        where TInfo : class, new()
    {
        protected readonly Acc_Oracle _acc = new Acc_Oracle();
        protected readonly Api_Common _api = new Api_Common();
        protected string UserError = string.Empty;
        protected string SystemError = string.Empty;
        protected int IDNew;
        public bool IsRemote
        {
            get { throw new NotImplementedException(); }
        }
        public int ID
        {
            get { return IDNew; }
        }
        public string SError
        {
            get { return UserError; }
        }
        
        public event GeneralEventHandler<TInfo> Added;

        public event GeneralEventHandler<TInfo> Updated;

        public event GeneralEventHandler<object> Removed;

        public event GeneralEventHandler<IList<TInfo>> ListAdded;

        public event GeneralEventHandler<IList<TInfo>> ListUpdated;

        public event GeneralEventHandler<IList<object>> ListRemoved;

        public virtual bool RequestAdd(TInfo info)
        {
            return false;
        }

        public virtual bool RequestAddList(IList<TInfo> infos)
        {
            return false;
        }

        public virtual bool RequestUpdate(TInfo info)
        {
            return false;
        }

        public virtual bool RequestUpdateList(IList<TInfo> infos)
        {
            return false;
        }

        public virtual bool RequestRemove(object id)
        {
            return false;
        }

        public virtual bool RequestRemoveList(IList<object> ids)
        {
            return false;
        }

        public virtual TInfo TryGet(object id)
        {
            return new TInfo(); 
        }

        public virtual IList<TInfo> GetData(object id)
        {
            return new List<TInfo>();
        }

        public virtual IList<TInfo> GetDataAll()
        {
            return new List<TInfo>();
        }

        public virtual IList<TInfo> GetDataIsActivity()
        {
            return new List<TInfo>();
        }

        public virtual IList<TInfo> GetDataIsActivityByGroup(object id)
        {
            return new List<TInfo>();
        }

        public virtual IList<TInfo> GetDataNotIsActivity()
        {
            return new List<TInfo>();
        }

        protected virtual void SetAdded(TInfo info)
        {
            if (Added != null) Added(this, new EventArgs<TInfo>(info));
        }
        protected virtual void SetListAdded(IList<TInfo> infos)
        {
            if (ListAdded != null) ListAdded(this, new EventArgs<IList<TInfo>>(infos));
        }

        protected virtual void SetUpdated(TInfo info)
        {
            if (Updated != null) Updated(this, new EventArgs<TInfo>(info));
        }

        protected virtual void SetListUpdated(IList<TInfo> infos)
        {
            if (ListUpdated != null) ListUpdated(this, new EventArgs<IList<TInfo>>(infos));
        }

        protected virtual void SetRemoved(object id)
        {
            if (Removed != null) Removed(this, new EventArgs<object>(id));
        }

        protected virtual void SetListRemoved(IList<object> ids)
        {
            if (Removed != null) ListRemoved(this, new EventArgs<IList<object>>(ids));
        }

        public virtual void  Copy<T>(TInfo info, T des) where T :class, new()
        {
            //Read Attribute Names and Types
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var objFieldNames = des.GetType().GetProperties(flags).Cast<PropertyInfo>().
                Select(item => new
                {
                    Name = item.Name,
                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType,
                    value = item.GetValue(des, null)
                }).ToList();

            foreach (var item in objFieldNames)
            {
                PropertyInfo propertyInfos = info.GetType().GetProperty(item.Name);
                PropertyInfo propertydes = des.GetType().GetProperty(item.Name);
                if (propertyInfos != null && propertydes != null)
                {
                    propertydes.SetValue(des, propertyInfos.GetValue(info, null), null);
                }
                //if (item.Name.Equals("CreateBy") || item.value == null)
                //{
                //    propertydes.SetValue(des, DataLocal.LoginedInfo.UserName, null);
                //}
                //if (item.Name.Equals("CreateDate") || item.value == null)
                //{
                //    propertydes.SetValue(des, DateTime.Now, null);
                //}
            }
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        protected  string GetMachine()
        {
           string _sql = string.Format("select SYS_CONTEXT('USERENV','IP_ADDRESS')||'+'||Userenv('TERMINAL')||'+'||SYS_CONTEXT('USERENV','MODULE') from dual");
            return _acc.Get_Data(_sql).Rows[0][0].ToString();
        }
        protected string Get_yyyymmddhhmissrdstt()
        {
            lock (syncLock)
            { 
                return _acc.Get_Data("select to_char(sysdate,'yymmddhh24miss') from dual", null).Rows[0][0].ToString() + random.Next(100000, 999999);
            }
        }
        public string GetError()
        {
            return UserError + " " + SystemError;
        }
        protected OracleParameter[] Set_OracleParameter(DataRow row)
        {
            OracleParameter[] result;
            try
            {
                OracleParameter[] arr = new OracleParameter[row.Table.Columns.Count];
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    arr[i] = new OracleParameter(":" + row.Table.Columns[i], row[row.Table.Columns[i]]);
                }
                result = arr;
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}
