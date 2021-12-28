using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcf_services
    {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
        {

        [OperationContract]
        List<Hotel> SearchHotels(string iCentreLat, string iCentreLon, int iRadius, string iMeasure, int iPageNumber,
                                    int iPageSize, string iSelectedStars, string iSort, out int oTotalRows);
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
        {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
            {
            get { return boolValue; }
            set { boolValue = value; }
            }

        [DataMember]
        public string StringValue
            {
            get { return stringValue; }
            set { stringValue = value; }
            }
        }
    }
