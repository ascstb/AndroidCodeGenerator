package com.example.mytestapp.di

import com.example.mytestapp.BuildConfig
import com.example.mytestapp.repository.remote.ServerAPI
import com.example.mytestapp.repository.remote.ServerRepository
import com.example.mytestapp.repository.remote.ServerRepositoryImpl
import org.koin.dsl.module

val serviceModule = module {
    single<ServerAPI> { createWebService(get(), BuildConfig.API_SERVER) }
    single<ServerRepository> { ServerRepositoryImpl(get()) }
}