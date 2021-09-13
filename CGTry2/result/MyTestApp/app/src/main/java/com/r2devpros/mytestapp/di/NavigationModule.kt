package com.r2devpros.mytestapp.di

import com.r2devpros.mytestapp.presentation.navigation.Navigation
import com.r2devpros.mytestapp.presentation.navigation.NavigationImpl
import org.koin.dsl.module

val navigationModule = module {
    single<Navigation> { NavigationImpl() }
}

val navigationModules = listOf(
    navigationModule
)