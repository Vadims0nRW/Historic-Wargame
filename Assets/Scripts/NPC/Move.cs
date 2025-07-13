using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interaction;

namespace NPC_Scripts
{
        [System.Serializable]
        public struct Order
    {
        public OrderImportance orderImportance;
        public OrderType orderType;
        public Transform orderTransform;

        public Order(OrderImportance importance, OrderType type, Transform transf)
        {
            orderImportance = importance;
            orderType = type;
            orderTransform = transf;
        }
    }

    public class Move : MonoBehaviour
    {
        NavMeshAgent agent;
        public List<Transform> patrolList;
        public List<Order> orderList;
        public Job job;
        public Transform workshopPosition;
        Order defaultOrder;
        bool busy = false;
        bool working = false;
        public const float stopDist = 2;
        public const float workDist = 2;

        // Инициализация
        void Start()
        {
            defaultOrder = new Order();
            agent = GetComponent<NavMeshAgent>();
            SetDefaultOrder(workshopPosition);
            orderList.Insert(0,defaultOrder);
        }

        // Обновление
        void Update()
        {
            
            if (!busy)
                ExecuteOrder();

            CheckOrderList();


        }

        // Установить приказ по умолчанию
        void SetDefaultOrder(Transform workshopTransform)
        {
            defaultOrder.orderImportance = OrderImportance.Regular;
            defaultOrder.orderType = OrderType.Work;
            defaultOrder.orderTransform = workshopTransform;
        }

        // Выполнить текущий приказ
        void ExecuteOrder()
        {
            Order order = orderList[0];
            busy = true;

            switch (order.orderType)
            {
                case OrderType.Battle:
                    ExecuteBattleOrder();
                    break;

                case OrderType.Interact:
                    break;

                case OrderType.Movement:
                    ExecuteMovingOrder(order.orderTransform);
                    break;

                case OrderType.Patrol:
                    ExecutePatrolOrder();
                    break;

                case OrderType.Work:
                    ExecuteWorkOrder();
                    break;
            }
        
        }

        // Перейти к следующему приказу
        void NextOrder()
        {
            CheckOrderList();
            orderList.RemoveAt(0);
            busy = false;
        }

        // Проверить список приказов
        void CheckOrderList()
        {

            if (orderList.Count == 1 && orderList[0].orderType != OrderType.Work)
                AddOrder(defaultOrder);

            if (orderList[0].orderType == OrderType.Work)
                working = true;
            else
                working = false;
        }

        // Переместиться к точке
        void ExecuteMovingOrder(Transform destinationPoint)
        {
            agent.SetDestination(destinationPoint.position);
            if (agent.remainingDistance < stopDist)
                NextOrder();
        }

        // !!!!! Описание приказа на работу
        void ExecuteWorkOrder()
        {
            busy = false;
            agent.SetDestination(workshopPosition.position);
            if (agent.remainingDistance < workDist)

            {
                Interact(workshopPosition);
                NextOrder();
            }

            CheckOrderList();
        }

        // !!!!! Выполнение приказа на патрулирование
        void ExecutePatrolOrder()
        {

        }

        // !!!!! Выполнение боевого приказа
        void ExecuteBattleOrder()
        {

        }

        // !!!!! Выполнение приказа на взаимодействие
        void ExecuteInteractOrder()
        {

        }

        // Добавить приказ в список
        public void AddOrder(Order order)
        {
            if (working)
            {
                orderList.Insert(0, order);
            }

            else
            {
                switch (order.orderImportance)
                {
                    // Добавить обычный приказ
                    case OrderImportance.Regular:
                        orderList.Insert(orderList.Count, order);
                        break;

                    // Добавить важный приказ
                    case OrderImportance.Important:
                        if (orderList.Count > 1)
                            orderList.Insert(1, order);
                        else
                            orderList.Insert(0, order);
                        break;

                    // Добавить очень важный приказ
                    case OrderImportance.VeryImportant:
                        orderList.Insert(0, order);
                        break;

                    // Добавить единственный приказ
                    case OrderImportance.OnlyThis:
                        ClearOrderList();
                        orderList.Insert(0, order);
                        break;

                }
            }

        }

        // Очичтить список приказов
        public void ClearOrderList()
        {
            orderList.Clear();
        }

        // Взаимодействовать с объектом
        void Interact(Transform interactableObject)
        {
            agent.SetDestination(interactableObject.position);

            if (agent.remainingDistance < workDist)
            {
                interactableObject.gameObject.GetComponent<Interactable>().Interact(gameObject);
            }
        }
    }


    
    
    
    // Работы
    public enum Job
    {
        None,
        Warrior,
        Peasant,
        Lumberjack,
        Miner,
        Blacksmith,
        Medic,
        Researcher,

    }
    // Типы приказов
    public enum OrderType
    {
        Battle,
        Interact,
        Movement,
        Work,
        Patrol,
    }
    // Важности приказов
    public enum OrderImportance
    {
        Regular,
        Important,
        VeryImportant,
        OnlyThis,
    }
  

}