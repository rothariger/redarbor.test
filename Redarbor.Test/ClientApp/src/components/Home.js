import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContent from '@mui/material/DialogContent';
import DialogActions from '@mui/material/DialogActions';
import moment from 'moment';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import { DesktopDatePicker } from '@mui/x-date-pickers/DesktopDatePicker';
import TextField from '@mui/material/TextField';

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

export class Home extends React.Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            candidates: [],
            loading: true,
            open: false,
            invalid: null,
            selected: {
                Name: null,
                Surname: null,
                Email: null,
                Birthdate: null
            }
        };

    }

    async loadAllCandidates() {
        const response = await fetch('api/Candidates');
        const data = await response.json();
        this.setState({ candidates: data });
    }

    componentDidMount() {
        this.loadAllCandidates();
    }

    onAgregarCandidato() {
        this.handleOpen();
        this.setState({
            selected: {
                Name: null,
                Surname: null,
                Email: null,
                Birthdate: null
            }
        });
    }

    handleOpen = () => this.setOpen(true);
    handleClose = () => this.setOpen(false);

    handleCancel = () => { this.handleClose(); }
    handleAgregarCandidato = async () => {
        this.handleClose();
        let sel = this.state.selected;
        sel.Birthdate = moment(sel.Birthdate).toDate();
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.state.selected)
        };
        const response = await fetch('api/Candidates', requestOptions);
        await response.json();
        await this.loadAllCandidates();
    }

    setOpen = (o) => this.setState({ open: o });

    handleChange = (e) => {
        let id = e.target.id;
        let value = e.target.value;
        let sel = this.state.selected;
        sel[id] = value;
        this.setState({ selected: sel });
    }

    render() {
        return (
            <div>
                <Button variant="outlined" onClick={() => { this.onAgregarCandidato(); }}>Agregar Candidato</Button>

                <Dialog
                    sx={{ '& .MuiDialog-paper': { width: '80%' } }}
                    maxWidth="xs"
                    open={this.state.open}
                >
                    <DialogTitle>Agregar Candidato</DialogTitle>
                    <DialogContent dividers>
                        <div>
                            <TextField
                                required
                                id="Name"
                                label="Name"
                                value={this.state.selected.Name}
                                onChange={this.handleChange}
                            />
                            <TextField
                                required
                                id="Surname"
                                label="Surname"
                                value={this.state.selected.Surname}
                                onChange={this.handleChange}
                            />
                            <TextField
                                required
                                id="Email"
                                label="Email"
                                value={this.state.selected.Email}
                                onChange={this.handleChange}
                            />
                            <TextField
                                required
                                id="Birthdate"
                                label="Birthdate"
                                value={this.state.selected.Birthdate}
                                onChange={this.handleChange}
                            />
                        </div>
                    </DialogContent>
                    <DialogActions>
                        <Button autoFocus onClick={this.handleCancel}>
                            Cancelar
                        </Button>
                        <Button onClick={this.handleAgregarCandidato}>Aceptar</Button>
                    </DialogActions>
                </Dialog>

                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 650 }} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Name</TableCell>
                                <TableCell >Surname</TableCell>
                                <TableCell >Birthdate</TableCell>
                                <TableCell >Email</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {this.state && this.state.candidates && this.state.candidates.map((row) => (
                                <TableRow
                                    key={row.idCandidate}
                                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                >
                                    <TableCell component="th" scope="row">
                                        {row.name}
                                    </TableCell>
                                    <TableCell >{row.surname}</TableCell>
                                    <TableCell >{moment(row.birthdate).format('DD/MM/YYYY')}</TableCell>
                                    <TableCell >{row.email}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>
        );
    }
}