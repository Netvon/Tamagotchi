using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Tamagotchi.Service.Model;

namespace Tamagotchi.Service
{
    [DataContract]
    public class CreateContract
    {
        public CreateContract(CreatedArguments createdArguments)
        {
            WasCreated = createdArguments.WasCreated;
            CreatedName = createdArguments.CreatedName;
            CreatedId = createdArguments.CreatedId;
        }

        [DataMember]
        public bool WasCreated { get; internal set; }

        [DataMember]
        public string CreatedName { get; internal set; }

        [DataMember]
        public int CreatedId { get; internal set; }

    }
}