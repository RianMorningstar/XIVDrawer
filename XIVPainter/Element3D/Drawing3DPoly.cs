﻿using XIVPainter.Element2D;

namespace XIVPainter.Element3D;

/// <summary>
/// A set of drawings
/// </summary>
public class Drawing3DPoly : Drawing3D
{
    /// <summary>
    /// The sub items.
    /// </summary>
    public IDrawing3D[] SubItems { get; set; }

    /// <summary>
    /// Convert this to the 2d elements.
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public override IEnumerable<IDrawing2D> To2D(XIVPainter owner)
    {
        return SubItems.SelectMany(i => i.To2D(owner));
    }

    /// <summary>
    /// The things that can be done in the task.
    /// </summary>
    /// <param name="painter"></param>
    public override void UpdateOnFrame(XIVPainter painter)
    {
        base.UpdateOnFrame(painter);
        foreach (var item in SubItems)
        {
            item.WarningRatio = WarningRatio;
            item.WarningTime = WarningTime;
            item.WarningType = WarningType;
            item.DeadTime = DeadTime;
            item.TimeToDisappear = TimeToDisappear;
            item.DisappearType = DisappearType;
            item.UpdateOnFrame(painter);
        }
    }
}
