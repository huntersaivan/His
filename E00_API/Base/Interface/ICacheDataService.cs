using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;


namespace E00_API.Base.Interface
{
    public class ErrorContainer
    {
        public int FrameNumber { get; set; }
        public String Reason { get; set; }

        public ErrorContainer() { }
        public ErrorContainer(int frameNumber, String reason)
        {
            FrameNumber = frameNumber;
            Reason = reason;
        }
    }

    public interface ICacheDataService<TInfo>  where TInfo : new()
    {
        /// <summary>
        /// True if remote data service, false if local
        /// </summary>
        Boolean IsRemote { get; }
        /// <summary>
        /// A Copy of Database
        /// </summary>
        //ICollection<TInfo> Data { get; }
        string GetError();
        event GeneralEventHandler<TInfo> Added;
        event GeneralEventHandler<TInfo> Updated;
        event GeneralEventHandler<object> Removed;

        event GeneralEventHandler<IList<TInfo>> ListAdded;
        event GeneralEventHandler<IList<TInfo>> ListUpdated;
        event GeneralEventHandler<IList<object>> ListRemoved;

        bool RequestAdd(TInfo info);
        bool RequestAddList(IList<TInfo> infos);

        bool RequestUpdate(TInfo info);
        bool RequestUpdateList(IList<TInfo> infos);

        bool RequestRemove(object id);
        bool RequestRemoveList(IList<object> ids);
        TInfo TryGet(object id);
        IList<TInfo> GetData(object id);
        IList<TInfo> GetDataAll();
        IList<TInfo> GetDataIsActivity();
        IList<TInfo> GetDataIsActivityByGroup(object id);
        IList<TInfo> GetDataNotIsActivity();
        void Copy<T>(TInfo info, T des) where T:class, new();
    }
}