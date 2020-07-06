package com.example.mytestapp.di

import com.example.mytestapp.presentation.navigation.Navigation
import com.example.mytestapp.presentation.navigation.NavigationImpl
import org.koin.dsl.module

@ExperimentalStdlibApi
val myAppModule = module {
    single<Navigation> { NavigationImpl() }
}