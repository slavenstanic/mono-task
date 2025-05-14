import { useEffect } from "react";
import { observer } from "mobx-react-lite";
import { Button, styled, TextField, Typography } from "@mui/material";
import vehicleListStore from "../stores/vehicleListStore";
import vehicleEditStore from "../stores/vehicleEditStore";
import {
  deleteVehicleMake,
  updateVehicleMake as updateVehicleMakeAPI,
} from "../services/vehicleMakeService";

const Root = styled("div")(() => ({
  display: "flex",
  flexDirection: "column",
  gap: "1rem",
  width: "34.75rem",
}));

const ListContainer = styled("div")(() => ({
  backgroundColor: "#092E49",
  color: "#fff",
  display: "flex",
  justifyContent: "space-between",
  alignItems: "center",
  padding: "0.625rem 0.75rem",
  borderRadius: "0.5rem",
}));

const TextFieldContainer = styled("div")(() => ({
  display: "flex",
  gap: "1.5rem",
  marginRight: "1rem",
}));

const ButtonContainer = styled("div")(() => ({
  display: "flex",
  gap: "0.5rem",
}));

const PagingContainer = styled("div")(() => ({
  display: "flex",
  justifyContent: "center",
  gap: "1.5rem",
}));

const VehicleMakeList = () => {
  const { vehicleMakes, page, totalPages, loading, setPage, loadVehicleMakes } =
    vehicleListStore;

  const { form, editId, setForm, resetForm, setEditId } = vehicleEditStore;

  useEffect(() => {
    loadVehicleMakes();
  }, []);

  const startEdit = (id: number, name: string, abrv: string) => {
    setEditId(id);
    setForm(name, abrv);
  };

  const cancelEdit = () => {
    resetForm();
  };

  const saveEdit = async () => {
    if (editId !== null) {
      await updateVehicleMakeAPI({ id: editId, ...form });
      await loadVehicleMakes();
      cancelEdit();
    }
  };

  if (loading) return <p>Loading...</p>;

  return (
    <Root>
      {vehicleMakes.map((make) => (
        <ListContainer key={make.id}>
          {editId === make.id ? (
            <>
              <TextFieldContainer>
                <TextField
                  name="name"
                  value={form.name}
                  onChange={(e) => setForm(e.target.name, e.target.value)}
                  sx={{
                    width: "100%",
                    backgroundColor: "#092E49",
                    border: "2px solid #5798C7",
                    borderRadius: "0.5rem",
                    input: {
                      color: "#fff",
                      fontSize: "0.875rem",
                      lineHeight: "1.125rem",
                      padding: "0.5rem 0.5rem 0.5rem 1rem",
                    },
                    "& .MuiOutlinedInput-notchedOutline": { border: "none" },
                  }}
                />
                <TextField
                  name="abrv"
                  value={form.abrv}
                  onChange={(e) => setForm(e.target.name, e.target.value)}
                  sx={{
                    width: "100%",
                    backgroundColor: "#092E49",
                    border: "2px solid #5798C7",
                    borderRadius: "0.5rem",
                    input: {
                      color: "#fff",
                      fontSize: "0.875rem",
                      lineHeight: "1.125rem",
                      padding: "0.5rem 0.5rem 0.5rem 1rem",
                    },
                    "& .MuiOutlinedInput-notchedOutline": { border: "none" },
                  }}
                />
              </TextFieldContainer>
              <ButtonContainer>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={saveEdit}
                >
                  Save
                </Button>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={cancelEdit}
                >
                  Cancel
                </Button>
              </ButtonContainer>
            </>
          ) : (
            <>
              <Typography>
                {make.name} - {make.abrv.toUpperCase()}
              </Typography>
              <ButtonContainer>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={() => startEdit(make.id, make.name, make.abrv)}
                >
                  Edit
                </Button>
                <Button
                  sx={{
                    backgroundColor: "#275B80",
                    color: "#fff",
                    fontSize: "0.75rem",
                    fontWeight: "500",
                    letterSpacing: "5%",
                    lineHeight: "1rem",
                    textTransform: "capitalize",
                    padding: "0.5rem 0.75rem",
                    borderRadius: "0.5rem",
                    "&:hover": {
                      backgroundColor: "#5798C7",
                    },
                    "&:active": {
                      backgroundColor: "#7DAFD3",
                    },
                  }}
                  onClick={async () => {
                    await deleteVehicleMake(make.id);
                    loadVehicleMakes();
                  }}
                >
                  Delete
                </Button>
              </ButtonContainer>
            </>
          )}
        </ListContainer>
      ))}
      <PagingContainer style={{ marginTop: "1rem" }}>
        <Button
          sx={{
            backgroundColor: "#275B80",
            color: "#fff",
            fontSize: "0.75rem",
            fontWeight: "500",
            letterSpacing: "5%",
            lineHeight: "1rem",
            textTransform: "capitalize",
            padding: "0.5rem 0.75rem",
            borderRadius: "0.5rem",
            "&:hover": { backgroundColor: "#5798C7" },
            "&:active": { backgroundColor: "#7DAFD3" },
            "&.Mui-disabled": {
              backgroundColor: "rgba(39, 91, 128, 0.3)",
              color: "rgba(255, 255, 255, 0.3)",
            },
          }}
          onClick={() => setPage(page - 1)}
          disabled={page === 1}
        >
          Previous
        </Button>
        <Typography sx={{ color: "#fff" }}>
          {totalPages === 0 ? "Page 0 of 0" : `Page ${page} of ${totalPages}`}
        </Typography>
        <Button
          sx={{
            backgroundColor: "#275B80",
            color: "#fff",
            fontSize: "0.75rem",
            fontWeight: "500",
            letterSpacing: "5%",
            lineHeight: "1rem",
            textTransform: "capitalize",
            padding: "0.5rem 0.75rem",
            borderRadius: "0.5rem",
            "&:hover": { backgroundColor: "#5798C7" },
            "&:active": { backgroundColor: "#7DAFD3" },
            "&.Mui-disabled": {
              backgroundColor: "rgba(39, 91, 128, 0.3)",
              color: "rgba(255, 255, 255, 0.3)",
            },
          }}
          onClick={() => setPage(page + 1)}
          disabled={page === totalPages || totalPages === 0}
        >
          Next
        </Button>
      </PagingContainer>
    </Root>
  );
};

export default observer(VehicleMakeList);
