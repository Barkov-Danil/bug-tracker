package com.bugtracker.bug_tracker_api;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

// сделать на фронте тикающий таймер с оставшимся временем до дедлайна
// подумать над приглашением в проект
// добавить на ВИ изменить комментарий
// если Данил согласится, добавить древовидную структуру для комментариев(с ответами на комменты)
@SpringBootApplication
public class BugTrackerApiApplication {

	public static void main(String[] args) {
		SpringApplication.run(BugTrackerApiApplication.class, args);
	}

}
