using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flat_Services_Application.Class
{
    [FirestoreData]
    public class room1
    {
        [FirestoreProperty]
        public int Status { get; set; }
        

    }
}
