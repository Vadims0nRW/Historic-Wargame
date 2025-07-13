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

        // �������������
        void Start()
        {
            defaultOrder = new Order();
            agent = GetComponent<NavMeshAgent>();
            SetDefaultOrder(workshopPosition);
            orderList.Insert(0,defaultOrder);
        }

        // ����������
        void Update()
        {
            
            if (!busy)
                ExecuteOrder();

            CheckOrderList();


        }

        // ���������� ������ �� ���������
        void SetDefaultOrder(Transform workshopTransform)
        {
            defaultOrder.orderImportance = OrderImportance.Regular;
            defaultOrder.orderType = OrderType.Work;
            defaultOrder.orderTransform = workshopTransform;
        }

        // ��������� ������� ������
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

        // ������� � ���������� �������
        void NextOrder()
        {
            CheckOrderList();
            orderList.RemoveAt(0);
            busy = false;
        }

        // ��������� ������ ��������
        void CheckOrderList()
        {

            if (orderList.Count == 1 && orderList[0].orderType != OrderType.Work)
                AddOrder(defaultOrder);

            if (orderList[0].orderType == OrderType.Work)
                working = true;
            else
                working = false;
        }

        // ������������� � �����
        void ExecuteMovingOrder(Transform destinationPoint)
        {
            agent.SetDestination(destinationPoint.position);
            if (agent.remainingDistance < stopDist)
                NextOrder();
        }

        // !!!!! �������� ������� �� ������
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

        // !!!!! ���������� ������� �� ��������������
        void ExecutePatrolOrder()
        {

        }

        // !!!!! ���������� ������� �������
        void ExecuteBattleOrder()
        {

        }

        // !!!!! ���������� ������� �� ��������������
        void ExecuteInteractOrder()
        {

        }

        // �������� ������ � ������
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
                    // �������� ������� ������
                    case OrderImportance.Regular:
                        orderList.Insert(orderList.Count, order);
                        break;

                    // �������� ������ ������
                    case OrderImportance.Important:
                        if (orderList.Count > 1)
                            orderList.Insert(1, order);
                        else
                            orderList.Insert(0, order);
                        break;

                    // �������� ����� ������ ������
                    case OrderImportance.VeryImportant:
                        orderList.Insert(0, order);
                        break;

                    // �������� ������������ ������
                    case OrderImportance.OnlyThis:
                        ClearOrderList();
                        orderList.Insert(0, order);
                        break;

                }
            }

        }

        // �������� ������ ��������
        public void ClearOrderList()
        {
            orderList.Clear();
        }

        // ����������������� � ��������
        void Interact(Transform interactableObject)
        {
            agent.SetDestination(interactableObject.position);

            if (agent.remainingDistance < workDist)
            {
                interactableObject.gameObject.GetComponent<Interactable>().Interact(gameObject);
            }
        }
    }


    
    
    
    // ������
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
    // ���� ��������
    public enum OrderType
    {
        Battle,
        Interact,
        Movement,
        Work,
        Patrol,
    }
    // �������� ��������
    public enum OrderImportance
    {
        Regular,
        Important,
        VeryImportant,
        OnlyThis,
    }
  

}