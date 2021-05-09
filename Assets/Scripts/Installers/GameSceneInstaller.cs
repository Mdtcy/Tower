using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using HellTap.PoolKit;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [InlineEditor(InlineEditorModes.FullEditor)]
    public GameObjectSet EnemySet;

    [InlineEditor(InlineEditorModes.FullEditor)]
    public GameObjectSet TowerSet;

    // [LabelText("floatingTextSpawner")]
    // [SerializeField]
    // private Spawner floatingTextSpawner;

    public override void InstallBindings()
    {
        EnemySet.Initialize();
        TowerSet.Initialize();

        InstallSignal();
        InstallPool();

        Container.BindInstance(EnemySet).WithId(ZenjectId.EnemySet);
        Container.BindInstance(TowerSet).WithId(ZenjectId.TowerSet);


    }

    private void InstallSignal()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<CollideSignal>();
        Container.DeclareSignal<KillEnemySignal>();

        Container.BindInterfacesTo<SignalProcesser>().AsSingle();
    }

    private void InstallPool()
    {
        // Container.BindInstance(floatingTextSpawner).WithId(ZenjectId.FloatingTextPool);
    }

}
