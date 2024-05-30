using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flat_Services_Application.Class
{
    
    [FirestoreData]
    public class listRequest
    {
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Room {  get; set; }

    }
}
