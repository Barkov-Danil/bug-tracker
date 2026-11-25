package com.bugtracker.bug_tracker_api.project.services;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import com.bugtracker.bug_tracker_api.project.domain.Project;
import com.bugtracker.bug_tracker_api.project.repository.ProjectRepository;
import com.bugtracker.bug_tracker_api.project.web.dto.ProjectResponse;

import java.util.List;
import java.util.UUID;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class ProjectService {

    private final ProjectRepository projectRepository;

    public List<ProjectResponse> getUserProjects(UUID userId) {
        List<Project> projects = projectRepository.findAllByUserId(userId);

        return projects.stream()
                .map(p -> new ProjectResponse(
                        p.getId(),
                        p.getName(),
                        p.getDescription(),
                        p.getLinkToRepo(),
                        p.getCreatedAt()
                ))
                .collect(Collectors.toList());
    }
}
