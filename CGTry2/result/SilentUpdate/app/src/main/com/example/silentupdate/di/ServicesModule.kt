package com.example.silentupdate.di

import com.example.silentupdate.BuildConfig
import com.example.silentupdate.repository.remote.ServerAPI
import com.example.silentupdate.repository.remote.ServerRepository
import com.example.silentupdate.repository.remote.ServerRepositoryImpl
import org.koin.dsl.module

val serviceModule = module {
    single<ServerAPI> { createWebService(get(), BuildConfig.API_SERVER) }
    single<ServerRepository> { ServerRepositoryImpl(get()) }
}