using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Service.Model;

namespace Tamagotchi.Service
{
    [ServiceContract]
    interface ITamagotchiService
    {
        [OperationContract]
        bool SleepByName(string name);

        [OperationContract]
        bool SleepById(int id);

        [OperationContract]
        bool EatByName(string name);

        [OperationContract]
        bool EatById(int id);

        [OperationContract]
        bool PlayByName(string name);

        [OperationContract]
        bool PlayById(int id);

        [OperationContract]
        bool WorkoutByName(string name);

        [OperationContract]
        bool WorkoutById(int id);

        [OperationContract]
        bool HugByName(string name);

        [OperationContract]
        bool HugById(int id);

        [OperationContract]
        TamagotchiContract GetTamagotchiByName(string name);

        [OperationContract]
        TamagotchiContract GetTamagotchiById(int id);

        [OperationContract]
        CreateContract AddTamagotchi(string name);

        [OperationContract]
        bool RemoveTamagotchiByName(string name);

        [OperationContract]
        bool RemoveTamagotchiById(int id);

        [OperationContract]
        bool IsKnownId(int id);

        [OperationContract]
        bool IsKnownName(string name);

        [OperationContract]
        IEnumerable<TamagotchiContract> GetAllTamagotchi(int start);

        [OperationContract]
        bool ActivateRuleForTamagotchiByName(string tamagotchiName, string ruleName);

        [OperationContract]
        bool ActivateRuleForTamagotchiById(int tamagotchiId, string ruleName);

        [OperationContract]
        bool DeactivateRuleForTamagotchiByName(string tamagotchiName, string ruleName);

        [OperationContract]
        bool DeactivateRuleForTamagotchiById(int tamagotchiId, string ruleName);

        [OperationContract]
        bool IsRunning();

        [OperationContract]
        int TamagotchiCount();

        [OperationContract]
        int TamagotchiPerPage();
    }
}
