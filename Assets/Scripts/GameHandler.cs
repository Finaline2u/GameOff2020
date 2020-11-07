using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    /*[SerializeField] private Transform shipNodeTransform = default;
    [SerializeField] private Transform scavengeTransform = default;*/
    [SerializeField] private TaskSystem[] workersAIList;
    private TaskSystem selectedWorkerAI;

    private List<Task> taskList;

    //[SerializeField] private Transform scavengerNodeTransform;

    private void Awake()
    {
        instance = this;
        Task.OnTaskClicked += OnTaskClicked;
        TaskSystem.OnWorkerClicked += OnWorkerSelected;
        taskList = new List<Task>();
        //taskList.Add(new BrokenShip(shipNodeTransform));
        //taskList.Add(new Task(scavengeTransform));
    }

    private void OnWorkerSelected(object sender, EventArgs e)
    {
        TaskSystem worker = sender as TaskSystem;
        selectedWorkerAI = worker;
        Debug.Log("Trabalhador selecionado.");
    }

    private void OnTaskClicked(object sender, EventArgs e)
    {
        Task taskClicked = sender as Task;
        Debug.Log("Tarefa selecionada.");
        selectedWorkerAI?.SetTask(taskClicked);
    }

    private Task GetTask()
    {
        return taskList[0];
    }

    public static Task GetTask_Static()
    {
        return instance.GetTask();
    }
}
