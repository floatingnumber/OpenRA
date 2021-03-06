#region Copyright & License Information
/*
 * Copyright 2007-2020 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using System;
using System.Linq;
using OpenRA.Mods.Common.Traits;
using OpenRA.Traits;

namespace OpenRA.Mods.Common.Lint
{
	class CheckHitShapes : ILintRulesPass
	{
		public void Run(Action<string> emitError, Action<string> emitWarning, ModData modData, Ruleset rules)
		{
			foreach (var actorInfo in rules.Actors)
			{
				var health = actorInfo.Value.TraitInfoOrDefault<IHealthInfo>();
				if (health == null)
					continue;

				var hitShapes = actorInfo.Value.TraitInfos<HitShapeInfo>();
				if (!hitShapes.Any())
					emitError("Actor type `{0}` has a Health trait but no HitShape trait!".F(actorInfo.Key));
			}
		}
	}
}
