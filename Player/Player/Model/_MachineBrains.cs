﻿// Presentation Karaoke Player
// File: _MachineBrains.cs
// 
// Copyright 2014, Arlo Belshee. All rights reserved. See LICENSE.txt for usage.

using JetBrains.Annotations;
using Player.ViewModels;

namespace Player.Model
{
	internal class _MachineBrains
	{
		[NotNull] private readonly KaraokeMachine _machine;

		private _MachineBrains([NotNull] KaraokeMachine machine)
		{
			_machine = machine;
			machine.Brains_TestAccess = this;
		}

		public void Start()
		{
			var initialSlide = Slide.BurningCar();
			initialSlide.MessageCenter = "Let's play!";
			_machine.ShowSlide(initialSlide);
		}

		public void AdvanceSlide()
		{
			var nextSlide = Slide.BurningCar();
			nextSlide.MessageTop = "You are so advanced!";
			_machine.ShowSlide(nextSlide);
		}

		public void Pause()
		{
		}

		public void Stop()
		{
		}

		public static void SupplyBrainFor([NotNull] KaraokeMachine machine)
		{
			var brains = new _MachineBrains(machine);
			machine.Pause.BindTo(brains.Pause);
			machine.AdvanceSlide.BindTo(brains.AdvanceSlide);
			machine.Stop.BindTo(brains.Stop);
			machine.Start.BindTo(brains.Start);
		}
	}
}