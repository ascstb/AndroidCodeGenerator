package com.example.silentupdate.di

import com.example.silentupdate.presentation.navigation.Navigation
import com.example.silentupdate.presentation.navigation.NavigationImpl
import org.koin.dsl.module

@ExperimentalStdlibApi
val myAppModule = module {
    single<Navigation> { NavigationImpl() }
}