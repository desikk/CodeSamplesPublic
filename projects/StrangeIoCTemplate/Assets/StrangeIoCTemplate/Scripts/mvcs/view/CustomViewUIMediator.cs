﻿/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.                                      
 */
// Marks the right margin of code *******************************************************************

//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using com.rmc.projects.strangeioc_template.mvc.controller.signals;
using com.rmc.projects.strangeioc_template.mvc.view.ui;
using com.rmc.projects.strangeioc_template.mvc.model;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.strangeioc_template.mvc.view
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class CustomViewUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// Gets or sets the view.
		/// </summary>
		/// <value>The view.</value>
		[Inject]
		public CustomViewUI view	{ get; set;}

		/// <summary>
		/// Gets or sets the custom model updated signal.
		/// </summary>
		/// <value>The custom model updated signal.</value>
		[Inject]
		public CustomModelUpdatedSignal customModelUpdatedSignal {get;set;}


		/// <summary>
		/// Gets or sets the custom view clear button click signal.
		/// </summary>
		/// <value>The custom view clear button click signal.</value>
		[Inject]
		public ClearButtonClickSignal customViewClearButtonClickSignal {get;set;}

		/// <summary>
		/// Gets or sets the custom view load button click signal.
		/// </summary>
		/// <value>The custom view load button click signal.</value>
		[Inject]
		public LoadButtonClickSignal customViewLoadButtonClickSignal {get;set;}

		/// <summary>
		/// Gets or sets all views initialized signal.
		/// </summary>
		/// <value>All views initialized signal.</value>
		[Inject]
		public AllViewsInitializedSignal allViewsInitializedSignal {get;set;}




		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		


		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{
			//
			view.loadMessageClickSignal.AddListener(onLoadMessageClick);
			view.clearMessageClickSignal.AddListener(onClearMessageClick);
			customModelUpdatedSignal.AddListener (onCustomModelUpdated);

			allViewsInitializedSignal.Dispatch ();

		}

		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			//
			view.loadMessageClickSignal.RemoveListener(onLoadMessageClick);
			view.clearMessageClickSignal.RemoveListener(onClearMessageClick);
			customModelUpdatedSignal.RemoveListener(onCustomModelUpdated);
		}

		
		//	PUBLIC
		/// <summary>
		/// Dos the render layout.
		/// </summary>
		/// <param name="aFavoriteVideogamesList_string">A favorite videogames list_string.</param>
		void doRenderLayout (List<string> aFavoriteVideogamesList_string)
		{
			view.favoriteVideogamesList = aFavoriteVideogamesList_string;
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------

		/// <summary>
		/// Ons the load message click.
		/// </summary>
		public void onLoadMessageClick ()
		{
			customViewLoadButtonClickSignal.Dispatch ();

		}

		/// <summary>
		/// Ons the load message click.
		/// </summary>
		public void onClearMessageClick ()
		{
			customViewClearButtonClickSignal.Dispatch ();
			
		}


		/// <summary>
		/// Ons the favorite videogames changed.
		/// </summary>
		/// <param name="aIEvent">A I event.</param>
		public void onCustomModelUpdated (CustomModel aCustomModel)
		{
			Debug.Log ("CustomView.onCustomModelUpdated() list: " + aCustomModel.favoriteVideogamesList);
			doRenderLayout(aCustomModel.favoriteVideogamesList);
			
		}

	}
}


