package com.bugtracker.bug_tracker_api;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

// сделать на фронте тикающий таймер с оставшимся временем до дедлайна
// подумать над приглашением в проект -- просто эндпоинт
// добавить на ВИ изменить комментарий
// проекты с не налл временем закрытия отображаются в архиве
// изменить эндпоинт для проекта getUserProjects: добавить jwt для id вместо параметра
// если Данил согласится, добавить древовидную структуру для комментариев(с ответами на комменты)
// сейчас отключен FlyWay(миграции)
// сейчас отключен Spring Security (файл config/SecurityConfig)
@SpringBootApplication
public class BugTrackerApiApplication {

	public static void main(String[] args) {
		SpringApplication.run(BugTrackerApiApplication.class, args);
	}

}
