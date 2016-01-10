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
        [OperationContract(Name = "SleepByName")]
        bool Sleep(string name);

        [OperationContract(Name = "SleepById")]
        bool Sleep(int id);

        [OperationContract(Name = "EatByName")]
        bool Eat(string name);

        [OperationContract(Name = "EatById")]
        bool Eat(int id);

        [OperationContract(Name = "PlayByName")]
        bool Play(string name);

        [OperationContract(Name = "PlayById")]
        bool Play(int id);

        [OperationContract(Name = "WorkoutByName")]
        bool Workout(string name);

        [OperationContract(Name = "WorkoutById")]
        bool Workout(int id);

        [OperationContract(Name = "HugByName")]
        bool Hug(string name);

        [OperationContract(Name = "HugById")]
        bool Hug(int id);

        [OperationContract(Name = "GetTamagotchiByName")]
        TamagotchiContract GetTamagotchi(string name);

        [OperationContract(Name = "GetTamagotchiById")]
        TamagotchiContract GetTamagotchi(int id);

        [OperationContract]
        CreateContract AddTamagotchi(string name);

        [OperationContract]
        bool RemoveTamagotchiByName(string name);

        [OperationContract]
        bool RemoveTamagotchiById(int id);

        [OperationContract]
        bool ValidId(int id);

        [OperationContract]
        bool ValidName(string name);

        [OperationContract]
        IEnumerable<TamagotchiContract> GetAllTamagotchi();

        [OperationContract(Name = "ActivateRuleForTamagotchiByName")]
        bool ActivateRuleForTamagotchi(string tamagotchiName, string ruleName);

        [OperationContract(Name = "ActivateRuleForTamagotchiById")]
        bool ActivateRuleForTamagotchi(int tamagotchiId, string ruleName);

        [OperationContract(Name = "DactivateRuleForTamagotchiByName")]
        bool DectivateRuleForTamagotchi(string tamagotchiName, string ruleName);

        [OperationContract(Name = "DactivateRuleForTamagotchiById")]
        bool DectivateRuleForTamagotchi(int tamagotchiId, string ruleName);

        [OperationContract]
        bool IsRunning();
    }
}
