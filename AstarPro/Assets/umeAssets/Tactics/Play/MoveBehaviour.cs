using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : IUnitBehaviour
{
    Unit unit;

    public MoveBehaviour(Unit _unit)
    {
        unit = _unit;
    }
    public void End()
    {
        var lpp = CompornentUtility.FindCompornentOnScene<LightPanelPopper>();
        lpp.AllActiveOff();
    }
    List<Point2> canMovePoints;
    public void SetUp()
    {

        var lpp = CompornentUtility.FindCompornentOnScene<LightPanelPopper>();
        var unitMoveChecker = CompornentUtility.FindCompornentOnScene<UnitMoveChecker>();
        canMovePoints = unitMoveChecker.GetCanMovePoint(unit);
        foreach (var p in canMovePoints)
        {
            lpp.ActiveOn(p,Color.blue);
        }
    }

    Point2 UnitMove()
    {
        BlockPointGetter blockData = RightClickRayShot.GetMouseRayHitObject<BlockPointGetter>(KeyCode.Mouse0);
        if (blockData != null && (canMovePoints.Contains(blockData.point)))
        {
            unit.MoveToPoint(blockData.point);
            return blockData.point;
        }
        return Point2.Empty;
    }
    public bool Update()
    {
        if (PlayerInfo.Instance.IsOnline)
        {
            if (unit.Army == PlayerInfo.Instance.team)
            {
                var  point= UnitMove();
                if (!point.isEmpty)
                {
                    //pointを通信で渡す関数
                }
                return point.isEmpty;
            }
            else
            {
                //通信でpointを持ってくる。
                //if (移動したら)
                //{
                //var point =ポイントを貰う関数
                //unit.MoveToPoint();
                //return point.isempty;
                //}
                //
            }
        }
        else
        {
            UnitMove();
        }
        return false;
    }
}
