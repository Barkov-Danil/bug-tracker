package user.domain;

import comment.domain.Comment;
import deadline_change_request.domain.DeadlineChangeRequest;
import fix.domain.Fix;
import jakarta.persistence.*;
import lombok.Data;
import notification.domain.NotificationRecipient;
import project.domain.ProjectMember;
import ticket.domain.Ticket;

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

    @OneToMany(mappedBy = "user")
    private List<NotificationRecipient> receivedNotifications;

    @OneToMany(mappedBy = "closedBy")
    private List<Ticket> ticketsClosedBy;

    @ManyToMany(mappedBy = "developers")
    private Set<Ticket> inProgressTickets = new HashSet<>();
}
