using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flat_Services_Application.Class
{
    [FirestoreData]
    public class Bill
    {
        [FirestoreProperty]
        public string Room_price { get; set; }

        [FirestoreProperty]
        public int amount_Elec { get; set; }

        [FirestoreProperty]
        public int amount_water { get; set; }

        [FirestoreProperty]
        public string clean { get; set; }

        [FirestoreProperty]
        public string debit { get; set; }

        [FirestoreProperty]
        public string elec { get; set; }

        [FirestoreProperty]
        public string secu { get; set; }

        [FirestoreProperty]
        public string service { get; set; }

        [FirestoreProperty]
        public string total { get; set; }

        [FirestoreProperty]
        public string water { get; set; }
    }
}
