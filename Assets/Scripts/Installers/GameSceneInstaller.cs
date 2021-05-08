using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [InlineEditor(InlineEditorModes.FullEditor)]
    public GameObjectSet EnemySet;

    [InlineEditor(InlineEditorModes.FullEditor)]
    public GameObjectSet TowerSet;

    public override void InstallBindings()
    {
        EnemySet.Initialize();
        TowerSet.Initialize();

        InstallSignal();

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

}
