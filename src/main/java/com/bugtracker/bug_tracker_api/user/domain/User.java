package com.bugtracker.bug_tracker_api.user.domain;

import com.bugtracker.bug_tracker_api.comment.domain.Comment;
import com.bugtracker.bug_tracker_api.deadline_change_request.domain.DeadlineChangeRequest;
import com.bugtracker.bug_tracker_api.fix.domain.Fix;
import jakarta.persistence.*;
import lombok.Data;
import com.bugtracker.bug_tracker_api.notification.domain.NotificationRecipient;
import com.bugtracker.bug_tracker_api.project.domain.ProjectMember;
import com.bugtracker.bug_tracker_api.ticket.domain.Ticket;

import java.time.OffsetDateTime;
import java.time.ZoneOffset;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.UUID;

@Entity
@Table(name = "users")
@Data
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private UUID id;

    @Column(nullable = false)
    private String surname;

    @Column(nullable = false)
    private String name;

    @Column(nullable = false, unique = true)
    private String email;

    @Column(nullable = false)
    private String passwordHash;

    @Column(nullable = false)
    private OffsetDateTime createdAt = OffsetDateTime.now(ZoneOffset.UTC);

    @OneToMany(mappedBy = "author")
    private List<DeadlineChangeRequest> deadlineRequestsWhereAuthor;

    @OneToMany(mappedBy = "reviewer")
    private List<DeadlineChangeRequest> deadlineRequestsWhereAssignee;

    @OneToMany(mappedBy = "author")
    private List<Ticket> ticketsWhereAuthor;

    @OneToMany(mappedBy = "user")
    private List<ProjectMember> projectMemberships;

    @OneToMany(mappedBy = "author")
    private List<Fix> fixesWhereAuthor;

    @OneToMany(mappedBy = "tester")
    private List<Fix> fixesWhereTester;

    @OneToMany(mappedBy = "author")
    private List<Comment> commentsWhereAuthor;

    @OneToMany(mappedBy = "recipient")
    private List<NotificationRecipient> receivedNotifications;

    @OneToMany(mappedBy = "closedBy")
    private List<Ticket> ticketsClosedBy;

    @ManyToMany(mappedBy = "developers")
    private Set<Ticket> inProgressTickets = new HashSet<>();
}
